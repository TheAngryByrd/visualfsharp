.assembly extern runtime { }
.assembly extern FSharp.Core { }
.assembly assembly
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  
  

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.assembly
{
  
  
}
.mresource public FSharpOptimizationData.assembly
{
  
  
}
.module assembly.exe

.imagebase {value}
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       
.corflags 0x00000001    





.class public auto ansi beforefieldinit AsyncTaskTest.TestClass
       extends [runtime]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 03 00 00 00 00 00 ) 
  .method public hidebysig instance class [runtime]System.Threading.Tasks.Task`1<string> 
          AsyncInstanceMethod() cil managed
  {
    .custom instance void [runtime]System.Runtime.CompilerServices.MethodImplAttribute::.ctor(valuetype [runtime]System.Runtime.CompilerServices.MethodImplOptions) = ( 01 00 00 20 00 00 00 00 ) 
    
    .maxstack  8
    IL_0000:  ldstr      "hello"
    IL_0005:  call       class [runtime]System.Threading.Tasks.Task`1<!0> [runtime]System.Threading.Tasks.Task`1<string>::FromResult(!0)
    IL_000a:  ret
  } 

  .method public static class [runtime]System.Threading.Tasks.Task`1<int32> 
          AsyncStaticMethod() cil managed
  {
    .custom instance void [runtime]System.Runtime.CompilerServices.MethodImplAttribute::.ctor(valuetype [runtime]System.Runtime.CompilerServices.MethodImplOptions) = ( 01 00 00 20 00 00 00 00 ) 
    
    .maxstack  8
    IL_0000:  ldc.i4.s   100
    IL_0002:  call       class [runtime]System.Threading.Tasks.Task`1<!0> [runtime]System.Threading.Tasks.Task`1<int32>::FromResult(!0)
    IL_0007:  ret
  } 

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance void [runtime]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  pop
    IL_0008:  ret
  } 

} 

.class public abstract auto ansi sealed AsyncTaskTest
       extends [runtime]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
} 

.class private abstract auto ansi sealed '<StartupCode$MethodImplAttribute-AsyncWithTask>'.$AsyncTaskTest
       extends [runtime]System.Object
{
  .method public static void  main@() cil managed
  {
    .entrypoint
    
    .maxstack  8
    IL_0000:  ret
  } 

} 


