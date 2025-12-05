// Test for MethodImplOptions.Async with Task return type
module AsyncTaskTest
open System.Threading.Tasks

type TestClass() =
    [<System.Runtime.CompilerServices.MethodImplAttribute(0x2000s)>]
    member _.AsyncInstanceMethod() : Task<string> = 
        Task.FromResult("hello")
    
    [<System.Runtime.CompilerServices.MethodImplAttribute(0x2000s)>]
    static member AsyncStaticMethod() : Task<int> = 
        Task.FromResult(100)
