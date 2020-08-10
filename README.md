# .NET for Apache Spark Examples
Example implementations of .NET for Apache Spark.

![.NET Core](https://github.com/usmanmohammed/dotnet-spark-samples/workflows/.NET%20Core/badge.svg?branch=master)

In this repo, we have various example implementations of .NET for Apache Spark. These examples cover:

Sample | Language
:--- | :---
Azure Blob Storage | [C#](), &nbsp; [F#]()

## Getting Started

### Download and Install Prerequisites
To get started, you'll need to download the following dependencies.
 1. [Apache Spark 2.4.1]()
 2. [.NET Core 3.1 SDK]()
 3. [JDK/OpenJDK 8]()
 4. [Microsoft.Spark.Worker]()

### Apache Spark 2.4.1
#### Windows
1. Download [Apache Spark 2.4.1]().
1. Create a directory e.g `C:\bin\`
2. Extract the downloaded Apache Spark archive into directory `C:\bin\spark-2.4.1-bin-hadoop2.7`
3. Create `SPARK_HOME` environment variable and set its value to the Apache Spark directory.
    ```sh
    setx SPARK_HOME "C:\bin\spark-2.4.1-bin-hadoop2.7"
    ```
4. Create `HADOOP_HOME` environment variable and set its value to the Apache Spark directory.
    ```sh
    setx SPARK_HOME "C:\bin\spark-2.4.1-bin-hadoop2.7"
    ```
5. Verify Apache Spark and Hadoop installation.
    ```sh
    spark-shell --version
    ```
#### Linux

1. Download [Apache Spark 2.4.1]().
1. Extract the downloaded Apache Spark archive into directory `~/bin/spark-2.4.1-bin-hadoop2.7`
2. Create `SPARK_HOME` environment variable and set its value to the Apache Spark directory.
    ```sh
    export SPARK_HOME="~/bin/spark-2.4.1-bin-hadoop2.7"
    ```
3. Create `HADOOP_HOME` environment variable and set its value to the Apache Spark directory.
    ```sh
    export HADOOP_HOME="~/bin/spark-2.4.1-bin-hadoop2.7"
    ```
4. Verify Apache Spark and Hadoop installation.
    ```sh
    spark-shell --version
    ```

### .NET Core 3.1 SDK
#### Windows
1. Download and install [.NET Core 3.1 SDK]().
5. Verify .NET installation.
    ```sh
    dotnet --version
    ```
#### Linux

1. Follow the instructions here: [Install .NET Core on Linux]().
4. Verify Apache Spark and Hadoop installation.
    ```sh
    dotnet --version
    ```

### Java Development Kit 8
#### Windows
1. Download and install [Java SE Development Kit 8](https://www.oracle.com/pt/java/technologies/javase/javase-jdk8-downloads.html).
5. Verify .NET installation.
    ```sh
    java --version
    ```
#### Linux

1. Follow the instructions here: [Open JDK: Download and install](https://openjdk.java.net/install/).
4. Verify Apache Spark and Hadoop installation.
    ```sh
    java --version
    ```


## Clone this Repo

## Build the Solution

## Run the Apps