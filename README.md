# .NET for Apache Spark Examples
Example implementations of .NET for Apache Spark.

![.NET Core](https://github.com/usmanmohammed/dotnet-spark-samples/workflows/.NET%20Core/badge.svg?branch=master)

In this repo, we have various example implementations of .NET for Apache Spark. These examples cover:

Sample | Language
:--- | :---
Azure Blob Storage | [C#](), &nbsp; [F#]()

## Prerequisites
To get started, you'll need the following installed on your machine.
 1. [Apache Spark 2.4.1]()
 2. [.NET Core 3.1 SDK]()
 3. [JDK/OpenJDK 8]()
 4. [Microsoft.Spark.Worker]()

## Install Prerequisites
### Apache Spark 2.4.1

1. Download [Apache Spark 2.4.1]().
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

1. Follow the instructions here: [Install .NET Core on Linux]() or [.NET Core 3.1 SDK]() for Windows.
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
    java --version
    ```
    
### Microsoft.Spark.Worker
1. Download [Microsoft.Spark.Worker]().
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

## Run Sample

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
    cd /xyz/abc/rrm
    ```

    **Windows**
    ```sh
    cd \xyz\abc\rrm
    ```
4. Submit application to run on Apache Spark
    
    **Linux**
    ```sh
    spark-submit \
    --packages org.apache.hadoop:hadoop-azure:2.7.3,com.microsoft.azure:azure-storage:3.1.0 \
    --class org.apache.spark.deploy.dotnet.DotnetRunner \
    --master local microsoft-spark-2.4.x-0.10.0.jar \
    ./mySparkBlobStorageApp $AZURE_STORAGE_ACCOUNT $AZURE_STORAGE_KEY
    ```

    **Windows**
    ```sh
    spark-submit ^
    --packages org.apache.hadoop:hadoop-azure:2.7.3,com.microsoft.azure:azure-storage:3.1.0 ^
    --class org.apache.spark.deploy.dotnet.DotnetRunner ^
    --master local microsoft-spark-2.4.x-0.10.0.jar ^
    mySparkBlobStorageApp %AZURE_STORAGE_ACCOUNT% %AZURE_STORAGE_KEY%
    ```
