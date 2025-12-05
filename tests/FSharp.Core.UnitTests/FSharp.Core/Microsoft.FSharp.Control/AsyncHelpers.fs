// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace FSharp.Core.UnitTests.Control

open System
open System.Threading
open System.Threading.Tasks
open System.Runtime.CompilerServices
open Xunit

#nowarn "57" // Experimental feature

module AsyncHelpersTests =
    
    [<Fact>]
    let ``AsyncHelpers.Await should wait for Task<int> and return result``() =
        let task = Task.FromResult(42)
        let result = AsyncHelpers.Await(task)
        Assert.Equal(42, result)
    
    [<Fact>]
    let ``AsyncHelpers.Await should wait for completed Task``() =
        let task = Task.CompletedTask
        AsyncHelpers.Await(task)
        // If we get here without exception, the test passed
        Assert.True(true)
    
    [<Fact>]
    let ``AsyncHelpers.Await should wait for ValueTask<int> and return result``() =
        let vtask = ValueTask<int>(42)
        let result = AsyncHelpers.Await(vtask)
        Assert.Equal(42, result)
    
    [<Fact>]
    let ``AsyncHelpers.Await should wait for ValueTask``() =
        let vtask = ValueTask()
        AsyncHelpers.Await(vtask)
        // If we get here without exception, the test passed
        Assert.True(true)
    
    [<Fact>]
    let ``AsyncHelpers.Await should work with delayed Task<string>``() =
        let task = 
            Task.Run(fun () ->
                Thread.Sleep(10)
                "hello")
        let result = AsyncHelpers.Await(task)
        Assert.Equal("hello", result)
    
    [<Fact>]
    let ``AsyncHelpers.Await should work with delayed Task``() =
        let mutable completed = false
        let task = 
            Task.Run(fun () ->
                Thread.Sleep(10)
                completed <- true)
        AsyncHelpers.Await(task)
        Assert.True(completed)

    [<Fact>]
    let ``AsyncHelpers.Await can be used in computation expression``() =
        #nowarn "57"
        
        type CEBuilder() =
            member inline _.Return(x: 'T) : Task<'T> = Task.FromResult(x)
            
            member inline _.Bind(t: Task<'T>, [<InlineIfLambda>] f: 'T -> Task<'U>) : Task<'U> =
                let result = AsyncHelpers.Await t
                f result
                
            member inline _.Bind(t: Task, [<InlineIfLambda>] f: unit -> Task<'U>) : Task<'U> =
                AsyncHelpers.Await t
                f ()
                
            member inline _.Delay([<InlineIfLambda>] f: unit -> Task<'T>) : Task<'T> = 
                f()
            
            member inline _.Run(f: Task<'T>) : Task<'T> = 
                f

        let ce = CEBuilder()

        let test() =
            ce {
                let! x = Task.FromResult(21)
                let! y = Task.FromResult(21)
                return x + y
            }
        
        let result = test()
        let finalResult = result.GetAwaiter().GetResult()
        Assert.Equal(42, finalResult)
