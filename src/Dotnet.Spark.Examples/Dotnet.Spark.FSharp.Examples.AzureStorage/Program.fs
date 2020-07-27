open System
open Microsoft.Spark.Sql
open Microsoft.Spark.Sql.Types

[<EntryPoint>]
let main args =
    match args with
    | [| storageAccountName; storageAccountKey |] ->

        // Specify file path in Azure Storage
        let filePath = 
            sprintf "wasbs://dotnet-spark@%s.blob.core.windows.net/json/people.json" storageAccountName

        // Create SparkSession
        let spark =
            SparkSession.Builder()
                .AppName("Azure Storage example using .NET for Apache Spark")
                .Config("fs.wasbs.impl", "org.apache.hadoop.fs.azure.NativeAzureFileSystem")
                .Config(
                    sprintf "fs.azure.account.key.%s.blob.core.windows.net" storageAccountName,
                    storageAccountKey
                 )
                .GetOrCreate()

        // Create sample data
        let data = 
            [ GenericRow([|1; "John Doe"|]) 
              GenericRow([|2; "Jane Doe"|]) 
              GenericRow([|3; "Foo Bar"|]) ]

        // Create schema for sample data
        let schema = 
            StructType
                ([ StructField("Id", IntegerType())
                   StructField("Name", StringType()) ])

        // Create DataFrame using data and schema
        let df = spark.CreateDataFrame(data, schema)

        // Print DataFrame
        df.Show()

        // Write DataFrame to Azure Storage
        df.Write().Mode(SaveMode.Overwrite).Json(filePath)

        // Read saved DataFrame from Azure Storage
        let readDf = spark.Read().Json(filePath)

        // Print DataFrame
        readDf.Show()

        0
    | _ ->
        printfn "Usage: $AZURE_STORAGE_ACCOUNT $AZURE_STORAGE_KEY"
        1
