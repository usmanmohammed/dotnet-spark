using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using System;
using System.Collections.Generic;

namespace Dotnet.Spark.CSharp.Examples.AzureStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify environment variable
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: $AZURE_STORAGE_ACCOUNT $AZURE_STORAGE_KEY");

                Environment.Exit(1);
            }

            // Specify path in Azure Storage
            string sampleFilePath =
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
            df.Write().Mode(SaveMode.Overwrite).Json(sampleFilePath);

            // Read saved DataFrame from Azure Storage
            DataFrame readDf = spark.Read().Json(sampleFilePath);

            // Print DataFrame
            readDf.Show();
        }
    }
}

