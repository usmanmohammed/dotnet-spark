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
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: $ADLS_SP_CLIENT_ID $ADLS_SP_CLIENT_SECRET");
                Environment.Exit(1);
            }

            // Specify file path in Azure Storage
            string filePath =
                $"wasbs://dotnet-spark@{args[0]}.blob.core.windows.net/json/people.json";

            // Create SparkSession
            SparkSession spark = SparkSession
                .Builder()
                .AppName("Azure Storage example using .NET for Apache Spark")
                .Config("fs.wasbs.impl", "org.apache.hadoop.fs.azure.NativeAzureFileSystem")
                .Config($"fs.azure.account.key.{args[0]}.blob.core.windows.net", args[1])
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

            // Write DataFrame to Azure Storage
            df.Write().Mode(SaveMode.Overwrite).Json(filePath);

            // Read saved DataFrame from Azure Storage
            DataFrame readDf = spark.Read().Json(filePath);

            // Print DataFrame
            readDf.Show();
        }
    }
}
