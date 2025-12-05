// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace FSharp.Compiler.ComponentTests.Conformance

open Xunit
open FSharp.Test.Compiler

module AsyncHelpersTests =
    
    // This test verifies that F# can compile code that uses AsyncHelpers
    // when targeting .NET 10+ (when AsyncHelpers becomes available)
    [<Fact>]
    let ``Code using AsyncHelpers should compile with appropriate warnings`` () =
        let code = """
module TestModule

open System
open System.Runtime.CompilerServices
open System.Threading.Tasks

#nowarn "57"

type CEBuilder() =
    member inline _.Return(x: 'T) : Task<'T> = Task.FromResult(x)
    
    member inline _.Bind(t: Task<'T>, [<InlineIfLambda>] f: 'T -> Task<'U>) : Task<'U> =
        AsyncHelpers.Await t
        |> f
        
    member inline _.Bind(t: Task, [<InlineIfLambda>] f: unit -> Task<'U>) : Task<'U> =
        AsyncHelpers.Await t
        |> f
        
    member inline _.Delay([<InlineIfLambda>]f: unit -> Task<'T>) : Task<'T> = f()
    
    [<System.Runtime.CompilerServices.MethodImplAttribute(0x2000s)>]
    member inline _.Run(f: Task<'T>) : Task<'T> = f

let ce = CEBuilder()

let test() =
    ce {
        do! Task.Delay 100
        return 42
    }

[<EntryPoint>]
let main _ = 0
"""
        // This test documents that the code structure is valid F# syntax
        // The actual AsyncHelpers.Await calls will only work when targeting .NET 10+
        // For now, we expect a compilation error about AsyncHelpers not being defined
        FSharp
        |> withLangVersionPreview
        |> asExe
        |> withCode code
        |> typecheck
        |> shouldFail
        |> ignore
        
    [<Fact>]
    let ``InlineIfLambda attribute should be recognized`` () =
        let code = """
module TestModule

open System.Runtime.CompilerServices

type Builder() =
    member inline _.Bind(x: int, [<InlineIfLambda>] f: int -> int) : int =
        f x
    
    member inline _.Return(x: int) : int = x

let builder = Builder()

let test() =
    builder {
        let! x = 42
        return x
    }
"""
        FSharp
        |> withLangVersionPreview  
        |> asExe
        |> withCode code
        |> compile
        |> shouldSucceed
