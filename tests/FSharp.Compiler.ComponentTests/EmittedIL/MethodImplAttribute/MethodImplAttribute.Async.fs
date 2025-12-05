// Test for MethodImplOptions.Async (0x2000) - Runtime-Async support (.NET 10+)
module M
open System.Threading.Tasks

[<System.Runtime.CompilerServices.MethodImplAttribute(0x2000s)>]
let asyncMethod () : Task<int> = Task.FromResult(42)
