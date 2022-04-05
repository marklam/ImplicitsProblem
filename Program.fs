open Pulumi
open Pulumi.AzureNative

// This isn't a working Pulumi app, it just sets up some deployment objects
// using the now-default implicit support in F#.
//
// It also used the 'old ' way of having to 'explicitly' call op_Implicit
//
// The two approaches generate different code, and the new code doesn't
// work when used from a real Pulumi app.

[<EntryPoint>]
let main argv =
    let matchValues = InputList<string>()
    matchValues.Add(Input.op_Implicit "HTTP")

    // This version
    // 	IL_003a: newobj instance void [Pulumi.AzureNative]Pulumi.AzureNative.Cdn.Inputs.RequestSchemeMatchConditionParametersArgs::.ctor()
    //  IL_003f: call class [Pulumi]Pulumi.Input`1<!0> class [Pulumi]Pulumi.Input`1<class [Pulumi.AzureNative]Pulumi.AzureNative.Cdn.Inputs.RequestSchemeMatchConditionParametersArgs>::op_Implicit(!0)
    //  IL_0044: stloc.3
    let conditionImplicit =
        Cdn.Inputs.DeliveryRuleRequestSchemeConditionArgs(
            Name = "RequestScheme1",
            Parameters =
                Cdn.Inputs.RequestSchemeMatchConditionParametersArgs(
                    MatchValues = matchValues,
                    Operator = Input.op_Implicit "Equal",
                    OdataType = Input.op_Implicit "#Microsoft.Azure.Cdn.Models.DeliveryRuleRequestSchemeConditionParameters"
                )
        )

    // This version
    //  IL_0093: newobj instance void [Pulumi.AzureNative]Pulumi.AzureNative.Cdn.Inputs.RequestSchemeMatchConditionParametersArgs::.ctor()
    //  IL_0098: stloc.s 6
    let conditionExplicit =
        Cdn.Inputs.DeliveryRuleRequestSchemeConditionArgs(
            Name = "RequestScheme2",
            Parameters =
                Input.op_Implicit (Cdn.Inputs.RequestSchemeMatchConditionParametersArgs(
                    MatchValues = matchValues,
                    Operator = Input.op_Implicit "Equal",
                    OdataType = Input.op_Implicit "#Microsoft.Azure.Cdn.Models.DeliveryRuleRequestSchemeConditionParameters"
                ))
        )

    0 // return an integer exit code
