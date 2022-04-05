using Pulumi;
using Pulumi.AzureNative.Cdn.Inputs;

namespace CSharpImplicits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matchValues = new InputList<string>
            {
                "HTTP"
            };

            // This version
            //IL_0023: newobj instance void [Pulumi.AzureNative]Pulumi.AzureNative.Cdn.Inputs.DeliveryRuleRequestSchemeConditionArgs::.ctor()
            //IL_0028: dup
            var conditionImplicit =
                new DeliveryRuleRequestSchemeConditionArgs {
                    Name = "RequestScheme1",
                    Parameters =
                        new RequestSchemeMatchConditionParametersArgs {
                            MatchValues = matchValues,
                            Operator = "Equal",
                            OdataType = "#Microsoft.Azure.Cdn.Models.DeliveryRuleRequestSchemeConditionParameters"
                        }
                };
        }
    }
}
