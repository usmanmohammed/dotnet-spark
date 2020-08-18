open System
open Microsoft.Spark.Sql
open Microsoft.Spark.Sql.Types

[<EntryPoint>]
let main args =
    match args with
    | [| tenantId; dataLakeName; servicePrincipalClientId; servicePrincipalSecret |] ->

        // Specify file path in Azure Data Lake Gen1
        let filePath = 
            sprintf "adl://%s.azuredatalakestore.net/parquet/people.parquet" dataLakeName

        // Create SparkSession
        let spark =
            SparkSession.Builder()
                .AppName("Azure Data Lake Storage example using .NET for Apache Spark")
                .Config("fs.adl.impl", "org.apache.hadoop.fs.adl.AdlFileSystem")
                .Config("fs.adl.oauth2.access.token.provider.type", "ClientCredential")
                .Config("fs.adl.oauth2.client.id",servicePrincipalClientId)
                .Config("fs.adl.oauth2.credential", servicePrincipalSecret)
                .Config("fs.adl.oauth2.refresh.url", 
                    sprintf "https://login.microsoftonline.com/%s/oauth2/token" tenantId)
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

        // Write DataFrame to Azure Data Lake Gen1
        df.Write().Mode(SaveMode.Overwrite).Parquet(filePath)

        // Read saved DataFrame from Azure Data Lake Gen1
        let readDf = spark.Read().Parquet(filePath)

        // Print DataFrame
        readDf.Show()

        0
    | _ ->
        printfn "Usage: $TENANT_ID $ADLS_NAME $ADLS_SP_CLIENT_ID $ADLS_SP_CLIENT_SECRET"
        1