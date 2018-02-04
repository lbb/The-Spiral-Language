module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_5(long long int * var_0, long long int * var_1, long long int * var_2);
    __device__ char method_6(long long int * var_0);
    
    __global__ void method_5(long long int * var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_6(var_7)) {
            long long int var_9 = var_7[0];
            long long int var_10 = (var_9 % 32);
            long long int var_11 = (var_9 / 32);
            long long int var_12 = (var_11 % 2);
            long long int var_13 = (var_11 / 2);
            long long int var_14 = (var_13 % 2);
            long long int var_15 = (var_13 / 2);
            char var_16 = (var_14 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_14 < 2);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_20 = (var_14 * 256);
            char var_21 = (var_12 >= 0);
            char var_23;
            if (var_21) {
                var_23 = (var_12 < 2);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_25 = (var_12 * 128);
            long long int var_26 = (var_20 + var_25);
            long long int var_27[1];
            var_27[0] = var_10;
            while (method_6(var_27)) {
                long long int var_29 = var_27[0];
                char var_30 = (var_29 >= 0);
                char var_32;
                if (var_30) {
                    var_32 = (var_29 < 128);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_34 = (var_26 + var_29);
                var_0[var_34] = var_14;
                var_1[var_34] = var_12;
                var_2[var_34] = var_29;
                long long int var_35 = (var_29 + 32);
                var_27[0] = var_35;
            }
            long long int var_36 = var_27[0];
            long long int var_37 = (var_9 + 128);
            var_7[0] = var_37;
        }
        long long int var_38 = var_7[0];
    }
    __device__ char method_6(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
}
"""

type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: ManagedCuda.BasicTypes.CUdeviceptr
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack2 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: EnvStack2
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env3) = var_1.Peek()
        let (var_7: EnvStack2) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_7((var_0: EnvStack2), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: EnvStack2), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: EnvStack2), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: ManagedCuda.CudaContext)): unit =
    let (var_22: int64) = (var_16 - var_15)
    let (var_23: int64) = (var_18 - var_17)
    let (var_24: int64) = (var_22 * var_23)
    let (var_25: int64) = (var_20 - var_19)
    let (var_26: int64) = (var_24 * var_25)
    let (var_27: bool) = (var_26 > 0L)
    let (var_28: bool) = (var_27 = false)
    if var_28 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_29: int64) = (var_23 * var_3)
    let (var_30: bool) = (var_2 = var_29)
    let (var_31: bool) = (var_30 = false)
    if var_31 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_32: int64) = (var_22 * var_2)
    let (var_33: int64) = (var_25 * var_4)
    let (var_34: bool) = (var_3 = var_33)
    let (var_35: bool) = (var_34 = false)
    if var_35 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_36: int64) = (var_32 * var_3)
    let (var_37: int64) = (var_23 * var_8)
    let (var_38: bool) = (var_7 = var_37)
    let (var_39: bool) = (var_38 = false)
    if var_39 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_40: int64) = (var_22 * var_7)
    let (var_41: int64) = (var_25 * var_9)
    let (var_42: bool) = (var_8 = var_41)
    let (var_43: bool) = (var_42 = false)
    if var_43 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_44: int64) = (var_40 * var_8)
    let (var_45: int64) = (var_23 * var_13)
    let (var_46: bool) = (var_12 = var_45)
    let (var_47: bool) = (var_46 = false)
    if var_47 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_48: int64) = (var_22 * var_12)
    let (var_49: int64) = (var_25 * var_14)
    let (var_50: bool) = (var_13 = var_49)
    let (var_51: bool) = (var_50 = false)
    if var_51 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_52: int64) = (var_48 * var_13)
    let (var_53: bool) = (var_1 = 0L)
    let (var_54: bool) = (var_53 = false)
    if var_54 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_55: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_26))
    let (var_56: (Union0 ref)) = var_0.mem_0
    let (var_57: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_56: (Union0 ref)))
    var_21.CopyToHost(var_55, var_57)
    let (var_58: bool) = (var_6 = 0L)
    let (var_59: bool) = (var_58 = false)
    if var_59 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_60: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_26))
    let (var_61: (Union0 ref)) = var_5.mem_0
    let (var_62: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_61: (Union0 ref)))
    var_21.CopyToHost(var_60, var_62)
    let (var_63: bool) = (var_11 = 0L)
    let (var_64: bool) = (var_63 = false)
    if var_64 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_65: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_26))
    let (var_66: (Union0 ref)) = var_10.mem_0
    let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_66: (Union0 ref)))
    var_21.CopyToHost(var_65, var_67)
    let (var_68: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_69: string) = ""
    let (var_70: int64) = 0L
    let (var_71: int64) = 0L
    method_8((var_68: System.Text.StringBuilder), (var_71: int64))
    let (var_72: System.Text.StringBuilder) = var_68.AppendLine("[|")
    let (var_73: int64) = method_9((var_68: System.Text.StringBuilder), (var_69: string), (var_55: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_60: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_65: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_70: int64))
    let (var_74: int64) = 0L
    method_8((var_68: System.Text.StringBuilder), (var_74: int64))
    let (var_75: System.Text.StringBuilder) = var_68.AppendLine("|]")
    let (var_76: string) = var_68.ToString()
    let (var_77: string) = System.String.Format("{0}",var_76)
    System.Console.WriteLine(var_77)
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: int64) = (var_3 % 256L)
    let (var_11: int64) = (var_3 - var_10)
    let (var_12: int64) = (var_11 + 256L)
    let (var_13: uint64) = (var_8 + var_9)
    let (var_14: uint64) = (var_1 + var_2)
    let (var_15: uint64) = uint64 var_12
    let (var_16: uint64) = (var_14 - var_13)
    let (var_17: bool) = (var_15 <= var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_12)))
    var_22
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: int64) = (var_2 % 256L)
    let (var_5: int64) = (var_2 - var_4)
    let (var_6: int64) = (var_5 + 256L)
    let (var_7: uint64) = (var_0 + var_1)
    let (var_8: uint64) = uint64 var_6
    let (var_9: uint64) = (var_7 - var_0)
    let (var_10: bool) = (var_8 <= var_9)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_13))))
    let (var_15: EnvStack2) = EnvStack2((var_14: (Union0 ref)))
    var_3.Push((Env3(var_15, var_6)))
    var_15
and method_8((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_8((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_9((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64)): int64 =
    let (var_24: bool) = (var_17 < var_18)
    if var_24 then
        let (var_25: bool) = (var_23 < 1000L)
        if var_25 then
            let (var_26: bool) = (var_17 >= var_17)
            let (var_27: bool) = (var_26 = false)
            if var_27 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_28: int64) = 0L
            method_10((var_0: System.Text.StringBuilder), (var_28: int64))
            let (var_29: System.Text.StringBuilder) = var_0.AppendLine("[|")
            let (var_30: int64) = method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_15: int64), (var_16: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64))
            let (var_31: int64) = 0L
            method_10((var_0: System.Text.StringBuilder), (var_31: int64))
            let (var_32: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_33: int64) = (var_17 + 1L)
            method_16((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_30: int64), (var_33: int64))
        else
            let (var_35: int64) = 0L
            method_8((var_0: System.Text.StringBuilder), (var_35: int64))
            let (var_36: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_23
    else
        var_23
and method_10((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_10((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64)): int64 =
    let (var_19: bool) = (var_14 < var_15)
    if var_19 then
        let (var_20: bool) = (var_18 < 1000L)
        if var_20 then
            let (var_21: bool) = (var_14 >= var_14)
            let (var_22: bool) = (var_21 = false)
            if var_22 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_23: int64) = 0L
            method_12((var_0: System.Text.StringBuilder), (var_23: int64))
            let (var_24: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_25: int64) = method_13((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_3: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_13: int64), (var_16: int64), (var_17: int64), (var_1: string), (var_18: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_27: int64) = (var_14 + 1L)
            method_15((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_25: int64), (var_27: int64))
        else
            let (var_29: int64) = 0L
            method_10((var_0: System.Text.StringBuilder), (var_29: int64))
            let (var_30: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_18
    else
        var_18
and method_16((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64)): int64 =
    let (var_25: bool) = (var_24 < var_18)
    if var_25 then
        let (var_26: bool) = (var_23 < 1000L)
        if var_26 then
            let (var_27: bool) = (var_24 >= var_17)
            let (var_28: bool) = (var_27 = false)
            if var_28 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_29: int64) = (var_24 - var_17)
            let (var_30: int64) = (var_29 * var_4)
            let (var_31: int64) = (var_3 + var_30)
            let (var_32: int64) = (var_29 * var_9)
            let (var_33: int64) = (var_8 + var_32)
            let (var_34: int64) = (var_29 * var_14)
            let (var_35: int64) = (var_13 + var_34)
            let (var_36: int64) = 0L
            method_10((var_0: System.Text.StringBuilder), (var_36: int64))
            let (var_37: System.Text.StringBuilder) = var_0.AppendLine("[|")
            let (var_38: int64) = method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_31: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_33: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_35: int64), (var_15: int64), (var_16: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64))
            let (var_39: int64) = 0L
            method_10((var_0: System.Text.StringBuilder), (var_39: int64))
            let (var_40: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_41: int64) = (var_24 + 1L)
            method_16((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_38: int64), (var_41: int64))
        else
            let (var_43: int64) = 0L
            method_8((var_0: System.Text.StringBuilder), (var_43: int64))
            let (var_44: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_23
    else
        var_23
and method_12((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 8L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_12((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_13((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: string), (var_13: int64)): int64 =
    let (var_14: bool) = (var_10 < var_11)
    if var_14 then
        let (var_15: bool) = (var_13 < 1000L)
        if var_15 then
            let (var_16: System.Text.StringBuilder) = var_0.Append(var_12)
            let (var_17: bool) = (var_10 >= var_10)
            let (var_18: bool) = (var_17 = false)
            if var_18 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_19: int64) = var_1.[int32 var_2]
            let (var_20: int64) = var_4.[int32 var_5]
            let (var_21: int64) = var_7.[int32 var_8]
            let (var_22: string) = System.String.Format("{0}",var_21)
            let (var_23: string) = System.String.Format("{0}",var_20)
            let (var_24: string) = System.String.Format("{0}",var_19)
            let (var_25: string) = String.concat ", " [|var_24; var_23; var_22|]
            let (var_26: string) = System.String.Format("[{0}]",var_25)
            let (var_27: System.Text.StringBuilder) = var_0.Append(var_26)
            let (var_28: string) = "; "
            let (var_29: int64) = (var_13 + 1L)
            let (var_30: int64) = (var_10 + 1L)
            method_14((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_28: string), (var_29: int64), (var_30: int64))
        else
            let (var_32: System.Text.StringBuilder) = var_0.Append("...")
            var_13
    else
        var_13
and method_15((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64)): int64 =
    let (var_20: bool) = (var_19 < var_15)
    if var_20 then
        let (var_21: bool) = (var_18 < 1000L)
        if var_21 then
            let (var_22: bool) = (var_19 >= var_14)
            let (var_23: bool) = (var_22 = false)
            if var_23 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_24: int64) = (var_19 - var_14)
            let (var_25: int64) = (var_24 * var_4)
            let (var_26: int64) = (var_3 + var_25)
            let (var_27: int64) = (var_24 * var_8)
            let (var_28: int64) = (var_7 + var_27)
            let (var_29: int64) = (var_24 * var_12)
            let (var_30: int64) = (var_11 + var_29)
            let (var_31: int64) = 0L
            method_12((var_0: System.Text.StringBuilder), (var_31: int64))
            let (var_32: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_33: int64) = method_13((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_26: int64), (var_5: int64), (var_6: (int64 [])), (var_28: int64), (var_9: int64), (var_10: (int64 [])), (var_30: int64), (var_13: int64), (var_16: int64), (var_17: int64), (var_1: string), (var_18: int64))
            let (var_34: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_35: int64) = (var_19 + 1L)
            method_15((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_33: int64), (var_35: int64))
        else
            let (var_37: int64) = 0L
            method_10((var_0: System.Text.StringBuilder), (var_37: int64))
            let (var_38: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_18
    else
        var_18
and method_14((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: string), (var_13: int64), (var_14: int64)): int64 =
    let (var_15: bool) = (var_14 < var_11)
    if var_15 then
        let (var_16: bool) = (var_13 < 1000L)
        if var_16 then
            let (var_17: System.Text.StringBuilder) = var_0.Append(var_12)
            let (var_18: bool) = (var_14 >= var_10)
            let (var_19: bool) = (var_18 = false)
            if var_19 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_20: int64) = (var_14 - var_10)
            let (var_21: int64) = (var_20 * var_3)
            let (var_22: int64) = (var_2 + var_21)
            let (var_23: int64) = (var_20 * var_6)
            let (var_24: int64) = (var_5 + var_23)
            let (var_25: int64) = (var_20 * var_9)
            let (var_26: int64) = (var_8 + var_25)
            let (var_27: int64) = var_1.[int32 var_22]
            let (var_28: int64) = var_4.[int32 var_24]
            let (var_29: int64) = var_7.[int32 var_26]
            let (var_30: string) = System.String.Format("{0}",var_29)
            let (var_31: string) = System.String.Format("{0}",var_28)
            let (var_32: string) = System.String.Format("{0}",var_27)
            let (var_33: string) = String.concat ", " [|var_32; var_31; var_30|]
            let (var_34: string) = System.String.Format("[{0}]",var_33)
            let (var_35: System.Text.StringBuilder) = var_0.Append(var_34)
            let (var_36: string) = "; "
            let (var_37: int64) = (var_13 + 1L)
            let (var_38: int64) = (var_14 + 1L)
            method_14((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_36: string), (var_37: int64), (var_38: int64))
        else
            let (var_40: System.Text.StringBuilder) = var_0.Append("...")
            var_13
    else
        var_13
let (var_0: string) = cuda_kernels
let (var_1: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_1.Synchronize()
let (var_2: string) = System.Environment.get_CurrentDirectory()
let (var_3: string) = System.IO.Path.Combine(var_2, "nvcc_router.bat")
let (var_4: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_4.set_RedirectStandardOutput(true)
var_4.set_RedirectStandardError(true)
var_4.set_UseShellExecute(false)
var_4.set_FileName(var_3)
let (var_5: System.Diagnostics.Process) = System.Diagnostics.Process()
var_5.set_StartInfo(var_4)
let (var_7: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_5.OutputDataReceived.Add(var_7)
var_5.ErrorDataReceived.Add(var_7)
let (var_8: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_10: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
let (var_13: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_14: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_15: bool) = System.IO.File.Exists(var_14)
if var_15 then
    System.IO.File.Delete(var_14)
else
    ()
System.IO.File.WriteAllText(var_14, var_0)
let (var_16: bool) = System.IO.File.Exists(var_3)
if var_16 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_17: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_18: System.IO.StreamWriter) = System.IO.StreamWriter(var_17)
var_18.WriteLine("SETLOCAL")
let (var_19: string) = String.concat "" [|"CALL "; "\""; var_8; "\""|]
var_18.WriteLine(var_19)
let (var_20: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_9; "\""|]
var_18.WriteLine(var_20)
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:/cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
var_18.WriteLine(var_21)
var_18.Dispose()
var_17.Dispose()
let (var_22: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_23: bool) = var_5.Start()
let (var_24: bool) = (var_23 = false)
if var_24 then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_25: int32) = var_5.get_ExitCode()
let (var_26: bool) = (var_25 = 0)
let (var_27: bool) = (var_26 = false)
if var_27 then
    let (var_28: string) = System.String.Format("{0}",var_25)
    let (var_29: string) = String.concat ", " [|"NVCC failed compilation."; var_28|]
    let (var_30: string) = System.String.Format("[{0}]",var_29)
    (failwith var_30)
else
    ()
let (var_31: System.TimeSpan) = var_22.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_31
let (var_32: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_33: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_2|]
let (var_34: string) = System.String.Format("{0}",var_33)
System.Console.WriteLine(var_34)
let (var_35: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_36: ManagedCuda.BasicTypes.SizeT) = var_35.get_TotalGlobalMemory()
let (var_37: int64) = int64 var_36
let (var_38: float) = float var_37
let (var_39: float) = (0.100000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: EnvStack2) = EnvStack2((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_52: int64) = 4096L
let (var_53: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_52: int64))
let (var_54: int64) = 4096L
let (var_55: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_54: int64))
let (var_56: int64) = 4096L
let (var_57: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_56: int64))
let (var_58: (Union0 ref)) = var_53.mem_0
let (var_59: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_58: (Union0 ref)))
let (var_60: ManagedCuda.BasicTypes.SizeT) = var_59.Pointer
let (var_61: uint64) = uint64 var_60
let (var_62: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_61)
let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_62)
let (var_64: (Union0 ref)) = var_55.mem_0
let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_64: (Union0 ref)))
let (var_66: ManagedCuda.BasicTypes.SizeT) = var_65.Pointer
let (var_67: uint64) = uint64 var_66
let (var_68: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_67)
let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_68)
let (var_70: (Union0 ref)) = var_57.mem_0
let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_70: (Union0 ref)))
let (var_72: ManagedCuda.BasicTypes.SizeT) = var_71.Pointer
let (var_73: uint64) = uint64 var_72
let (var_74: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_73)
let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_74)
// Cuda join point
// method_5((var_63: ManagedCuda.BasicTypes.CUdeviceptr), (var_69: ManagedCuda.BasicTypes.CUdeviceptr), (var_75: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_76: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_5", var_32, var_1)
let (var_77: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_76.set_GridDimensions(var_77)
let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_76.set_BlockDimensions(var_78)
let (var_79: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_81: (System.Object [])) = [|var_63; var_69; var_75|]: (System.Object [])
var_76.RunAsync(var_79, var_81)
let (var_82: int64) = 0L
let (var_83: int64) = 256L
let (var_84: int64) = 128L
let (var_85: int64) = 1L
let (var_86: int64) = 0L
let (var_87: int64) = 256L
let (var_88: int64) = 128L
let (var_89: int64) = 1L
let (var_90: int64) = 0L
let (var_91: int64) = 256L
let (var_92: int64) = 128L
let (var_93: int64) = 1L
let (var_94: int64) = 0L
let (var_95: int64) = 2L
let (var_96: int64) = 0L
let (var_97: int64) = 2L
let (var_98: int64) = 0L
let (var_99: int64) = 128L
method_7((var_53: EnvStack2), (var_82: int64), (var_83: int64), (var_84: int64), (var_85: int64), (var_55: EnvStack2), (var_86: int64), (var_87: int64), (var_88: int64), (var_89: int64), (var_57: EnvStack2), (var_90: int64), (var_91: int64), (var_92: int64), (var_93: int64), (var_94: int64), (var_95: int64), (var_96: int64), (var_97: int64), (var_98: int64), (var_99: int64), (var_1: ManagedCuda.CudaContext))
var_58 := Union0Case1
var_64 := Union0Case1
var_70 := Union0Case1
var_51.Dispose()
let (var_100: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_100)
var_46 := Union0Case1
var_1.Dispose()

