// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

// Support for System.Runtime.CompilerServices.AsyncHelpers
// This provides type-forwarding and compatibility shims for the new .NET 10 AsyncHelpers API

namespace System.Runtime.CompilerServices

open System
open System.Threading.Tasks

#if !NET10_0_OR_GREATER

/// <summary>
/// Provides helper methods for consuming Tasks and ValueTasks synchronously.
/// This is a compatibility shim for .NET versions prior to 10.0.
/// When targeting .NET 10.0 or later, the runtime-provided implementation is used.
/// </summary>
[<Sealed>]
[<RequireQualifiedAccess>]
[<Experimental("Preview library feature, requires '--langversion:preview'. This warning can be disabled using '--nowarn:57' or '#nowarn \"57\"'.")>]
type AsyncHelpers =
    
    /// <summary>
    /// Synchronously waits for the task to complete and returns its result.
    /// </summary>
    /// <param name="task">The task to wait for.</param>
    /// <returns>The result of the completed task.</returns>
    static member inline Await(task: Task<'T>) : 'T =
        task.GetAwaiter().GetResult()
    
    /// <summary>
    /// Synchronously waits for the task to complete.
    /// </summary>
    /// <param name="task">The task to wait for.</param>
    static member inline Await(task: Task) : unit =
        task.GetAwaiter().GetResult()
    
    /// <summary>
    /// Synchronously waits for the value task to complete and returns its result.
    /// </summary>
    /// <param name="task">The value task to wait for.</param>
    /// <returns>The result of the completed value task.</returns>
    static member inline Await(task: ValueTask<'T>) : 'T =
        task.GetAwaiter().GetResult()
    
    /// <summary>
    /// Synchronously waits for the value task to complete.
    /// </summary>
    /// <param name="task">The value task to wait for.</param>
    static member inline Await(task: ValueTask) : unit =
        task.GetAwaiter().GetResult()

#endif
