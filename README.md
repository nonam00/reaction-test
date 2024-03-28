# Reaction Test Application

Welcome to the Reaction Test Application repository! This is a single page application designed to test your reaction time and improve your cognitive skills. 

## Description

The Reaction Test Application is a simple yet effective tool to measure your reaction time. The application presents a visual stimulus, and the user's task is to respond as quickly as possible. The reaction time is then recorded and displayed to the user. This can be used for fun challenges, brain training, or even to track improvements in reaction speed over time.

## Features

- Measure and display reaction time
- Simple and intuitive user interface
- Authentication and authorization
- Displays history of recent tests

## Requirements:

- git
- dotnet sdk 8
- node.js v20.11.1

## Installation and launch of the project

To install and run the application, follow these steps:

1. Clone the repository: 
   ```bash
   git clone https://github.com/nonam00/reaction-test
   ```

2. Generate HTTPS certificate for API and Identity Server
   ```bash
   dotnet dev-certs https --trust
   ```

3. Launch API and Identity Server
   ```bash
   dotnet run --launch-profile https
   ```

4. Install Node.js dependencies:
   ```bash
   npm i
   ```
   
5. Launch React app
   ```bash
   npm start
   ```
     
6. Open your web browser and go to http://localhost:3000 to access the application.
    
## Usage

Once the application is running, follow the on-screen instructions to start the reaction test. The application will guide you through the process and display your reaction time at the end of each test.

## Contributing

If you'd like to contribute to the Reaction Test Application, please follow these guidelines:

1. Fork the repository
2. Create a new branch for your feature or bug fix
3. Make your changes and commit them with descriptive messages
4. Push your branch to your fork
5. Open a pull request to the main repository
