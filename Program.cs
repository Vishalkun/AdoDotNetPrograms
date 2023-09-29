namespace ADOnetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // CustomerOperations.createdatabase();
            //CustomerOperations.CreateTable();
            CustomerModel model = new CustomerModel();
            /*model.Name = "Test";
            model.city = "Mumbai";
            model.phone = 121343;*/
            //CustomerOperations.InsertUsingStoredProcedure(model);

            CustomerOperations.InsertUsingStoredProcedure(model);
        }
    }
}