using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using System;
using System.Collections.Generic;

namespace Dotnet.Spark.CSharp.Examples.AzureDataLakeStorageGen1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify environment variables
            if (args.Length != 4)
            {
                Console.Error.WriteLine("Usage: $TENANT_ID $ADLS_NAME $ADLS_SP_CLIENT_ID $ADLS_SP_CLIENT_SECRET");
                Environment.Exit(1);
            }

            // Specify file path in Azure Data Lake Gen 1
            string filePath =
                $"adl://{args[1]}.azuredatalakestore.net/parquet/people.parquet";

            // Create SparkSession
            SparkSession spark = SparkSession
                .Builder()
                .AppName("Azure Data Lake Store example using .NET for Apache Spark")
                .Config("fs.adl.impl", "org.apache.hadoop.fs.adl.AdlFileSystem")
                .Config("fs.adl.oauth2.access.token.provider.type", "ClientCredential")
                .Config("fs.adl.oauth2.client.id", args[2])
                .Config("fs.adl.oauth2.credential", args[3])
                .Config("fs.adl.oauth2.refresh.url", $"https://login.microsoftonline.com/{args[0]}/oauth2/token")
                .GetOrCreate();

            // Create sample data
            var data = new List<GenericRow>
            {
                new GenericRow(new object[] { 1, "John Doe"}),
                new GenericRow(new object[] { 2, "Jane Doe"}),
                new GenericRow(new object[] { 3, "Foo Bar"})
            };

            // Create schema for sample data
            var schema = new StructType(new List<StructField>()
            {
                new StructField("Id", new IntegerType()),
                new StructField("Name", new StringType()),
            });

            // Create DataFrame using data and schema
            DataFrame df = spark.CreateDataFrame(data, schema);

            // Print DataFrame
            df.Show();

            // Write DataFrame to Azure Data Lake Gen 1
            df.Write().Mode(SaveMode.Overwrite).Parquet(filePath);

            // Read saved DataFrame from Azure Data Lake Gen 1
            DataFrame readDf = spark.Read().Parquet(filePath);

            // Print DataFrame
            readDf.Show();
        }
    }
}
