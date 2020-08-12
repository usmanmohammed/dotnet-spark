# .NET for Apache Spark Samples
Example implementations of .NET for Apache Spark.

![.NET Core](https://github.com/usmanmohammed/dotnet-spark-samples/workflows/.NET%20Core/badge.svg?branch=master)

In this repo, we have various example implementations of .NET for Apache Spark. These examples cover:

Sample | Language
:--- | :---
Azure Blob Storage | [C#](https://github.com/usmanmohammed/dotnet-spark-samples/tree/master/src/Dotnet.Spark.Examples/Dotnet.Spark.CSharp.Examples.AzureStorage), &nbsp; [F#](https://github.com/usmanmohammed/dotnet-spark-samples/tree/master/src/Dotnet.Spark.Examples/Dotnet.Spark.FSharp.Examples.AzureStorage)

## Getting Started
The following guide will show you how to get samples up and running on your local machine.
## Prerequisites
To get started, you'll need the following installed on your machine.
 1. Apache Spark 2.4.1
 2. .NET Core 3.1 SDK
 3. JDK 8
 4. Microsoft.Spark.Worker 0.12.1

## Install Prerequisites
### Apache Spark 2.4.1

1. Download [Apache Spark 2.4.1](https://spark.apache.org/downloads.html).
1. Extract contents of the downloaded Apache Spark archive into the following directory.
  
    **Linux** 
    ```sh
    ~/bin/spark-2.4.1-bin-hadoop2.7
    ```  
    **Windows**
    ```sh
    C:\bin\spark-2.4.1-bin-hadoop2.7
    ``` 
3. Create `SPARK_HOME` and `HADOOP_HOME` environment variables and set their values to the Apache Spark directory.
    
    **Linux**    
    ```sh
    export SPARK_HOME="~/bin/spark-2.4.1-bin-hadoop2.7"
    export HADOOP_HOME="~/bin/spark-2.4.1-bin-hadoop2.7"
    ``` 
    **Windows**    
    ```sh
    setx SPARK_HOME "C:\bin\spark-2.4.1-bin-hadoop2.7"
    setx HADOOP_HOME "C:\bin\spark-2.4.1-bin-hadoop2.7"
    ```
4. Verify Apache Spark and Hadoop installation.
    ```sh
    spark-shell --version
    ```

### .NET Core 3.1 SDK

1. Follow the instructions here: [Install .NET Core on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) or [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) for Windows.
4. Verify .NET Core SDK installation.
    
    ```sh
    dotnet --version
    ```

### JDK 8
1. Follow the instructions here: 
    - Windows: [Open JDK: Download and install](https://openjdk.java.net/install/).
    - Linux: [Java SE Development Kit 8](https://www.oracle.com/pt/java/technologies/javase/javase-jdk8-downloads.html).

4. Verify JDK installation.
    
    ```sh
    java -version
    ```
    
### Microsoft.Spark.Worker 0.12.1
1. Download [Microsoft.Spark.Worker 0.12.1](https://github.com/dotnet/spark/releases/download/v0.12.1/Microsoft.Spark.Worker.netcoreapp3.1.win-x64-0.12.1.zip).
1. Extract contents of the downloaded archive into the following directory.

    **Linux**
    ```sh
    ~/bin/Microsoft.Spark.Worker
    ```

    **Windows**
    ```sh
    C:\bin\Microsoft.Spark.Worker
    ```
    
3. Create `DOTNET_WORKER_DIR` environment variable and set its value to Microsoft.Spark.Worker directory.

    **Linux**
    ```sh
    export DOTNET_WORKER_DIR="~/bin/Microsoft.Spark.Worker"
    ```

    **Windows**
    ```sh
    setx DOTNET_WORKER_DIR "C:\bin\Microsoft.Spark.Worker"
    ```

## Build Samples

1. Clone the repo.

    ```sh
    git clone https://github.com/usmanmohammed/dotnet-spark-samples.git
    ```
2. Navigate to the solution directory.

    ```sh
    cd dotnet-spark-samples
    ```
3. Restore and build the solution.

    ```sh
    dotnet build
    ```

## Run Samples

### Azure Blob Storage
1. Get your Azure Blob Storage Access Key. This can be accessed from the Azure Portal.
2. Create environment variables for your Blob Storage Account Name (`AZURE_STORAGE_ACCOUNT`) and Access Key (`AZURE_STORAGE_KEY`).

    **Linux**
    ```sh
    export $AZURE_STORAGE_ACCOUNT="<storage-account-name>"
    export $AZURE_STORAGE_KEY="<storage-account-key>"
    ```

    **Windows**
    ```sh
    setx AZURE_STORAGE_ACCOUNT "<storage-account-name>"
    setx AZURE_STORAGE_KEY "<storage-account-key>"
    ```
3. Go to build output directory.
    
    **Linux**
    ```sh
    cd src/Dotnet.Spark.Examples/Dotnet.Spark.CSharp.Examples.AzureStorage/bin/Debug/netcoreapp3.1
    ```

    **Windows**
    ```sh
    cd .\src\Dotnet.Spark.Examples\Dotnet.Spark.CSharp.Examples.AzureStorage\bin\Debug\netcoreapp3.1
    ```
4. Submit application to run on Apache Spark.
    
    **Linux**
    ```sh
    spark-submit \
    --packages org.apache.hadoop:hadoop-azure:2.7.3,com.microsoft.azure:azure-storage:3.1.0 \
    --class org.apache.spark.deploy.dotnet.DotnetRunner \
    --master local microsoft-spark-2.4.x-0.12.1.jar \
    ./mySparkBlobStorageApp $AZURE_STORAGE_ACCOUNT $AZURE_STORAGE_KEY
    ```

    **Windows**
    ```sh
    spark-submit ^
    --packages org.apache.hadoop:hadoop-azure:2.7.3,com.microsoft.azure:azure-storage:3.1.0 ^
    --class org.apache.spark.deploy.dotnet.DotnetRunner ^
    --master local microsoft-spark-2.4.x-0.12.1.jar ^
    mySparkBlobStorageApp %AZURE_STORAGE_ACCOUNT% %AZURE_STORAGE_KEY%
    ```
    
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Feel free to open a PR.

## License

Distributed under the MIT License. See `LICENSE` for more information.
