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
#### Linux

1. Download [Apache Spark 2.4.1]().
1. Extract contents of the downloaded Apache Spark archive into directory `~/bin/spark-2.4.1-bin-hadoop2.7`
3. Create `SPARK_HOME` and `HADOOP_HOME` environment variables and set their values to the Apache Spark directory 
    ```sh
    export SPARK_HOME="~/bin/spark-2.4.1-bin-hadoop2.7"
    export HADOOP_HOME="~/bin/spark-2.4.1-bin-hadoop2.7"
    ```
4. Verify Apache Spark and Hadoop installation.
    ```sh
    spark-shell --version
    ```

#### Windows
1. Download [Apache Spark 2.4.1]().
1. Create a directory e.g `C:\bin\`
2. Extract contents of the downloaded Apache Spark archive into directory `C:\bin\spark-2.4.1-bin-hadoop2.7`
3. Create `SPARK_HOME` and `HADOOP_HOME` environment variables and set their values to the Apache Spark directory 
   ```sh
   setx SPARK_HOME "C:\bin\spark-2.4.1-bin-hadoop2.7"
   setx HADOOP_HOME "C:\bin\spark-2.4.1-bin-hadoop2.7"
    ```
5. Verify Spark and Hadoop installation.
    ```sh
    spark-shell --version
    ```

### .NET Core 3.1 SDK
#### Linux

1. Follow the instructions here: [Install .NET Core on Linux]().
4. Verify .NET Core SDK installation.
    ```sh
    dotnet --version
    ```
#### Windows

1. Download and install [.NET Core 3.1 SDK]().
5. Verify .NET Core SDK installation.
    ```sh
    dotnet --version
    ```

### JDK 8

#### Linux

1. Follow the instructions here: [Open JDK: Download and install](https://openjdk.java.net/install/).
4. Verify Apache JDK installation.
    ```sh
    java --version
    ```

#### Windows
1. Download and install [Java SE Development Kit 8](https://www.oracle.com/pt/java/technologies/javase/javase-jdk8-downloads.html).
5. Verify JDK installation.
    ```sh
    java --version
    ```

### Microsoft.Spark.Worker

#### Linux

1. Download [Microsoft.Spark.Worker]().
2. Extract contents of the downloaded archive into directory `~/bin/Microsoft.Spark.Worker`
3. Create `DOTNET_WORKER_DIR` environment variable and set its value to Microsoft.Spark.Worker directory.
    ```sh
    export DOTNET_WORKER_DIR="~/bin/Microsoft.Spark.Worker"
    ```
#### Windows
1. Download [Microsoft.Spark.Worker]().
2. Extract contents of the downloaded archive into directory `C:\bin\Microsoft.Spark.Worker`
3. Create `DOTNET_WORKER_DIR` environment variable and set its value to Microsoft.Spark.Worker directory.
    ```sh
    setx DOTNET_WORKER_DIR "C:\bin\Microsoft.Spark.Worker"
    ``` 
## Clone this Repo

## Build the Solution

## Run the Apps
