# Reaction Test Application

Welcome to the Reaction Test Application repository! This is a single page application designed to test your reaction time and improve your cognitive skills. 

## Description

The Reaction Test Application is a simple yet effective tool to measure your reaction time. The application presents a visual stimulus, and the user's task is to respond as quickly as possible. The reaction time is then recorded and displayed to the user. This can be used for fun challenges, brain training, or even to track improvements in reaction speed over time.

## Features

- Measure and display reaction time
- Simple and intuitive user interface
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

2. Navigate to the project directory:
   ```bash
   cd reaction-test
   ```

3. Move to the Backend directory:
   ```bash
   cd backend/webapi
   ```
   
4. Run the API:
   ```bash
   dotnet run --launch-profile "https"
   ```
   
5. Open another bash window on project directory
   
6. Move to the Frontend directory:
   ```bash
   cd frontend
   ```
7. Install node.js dependencies:
   ```bash
   npm i
   ```
8. Start the application (frontend):
   ```bash
   npm start
   ```
     
9. Open your web browser and go to http://localhost:3000 to access the application.
    
## Usage

Once the application is running, follow the on-screen instructions to start the reaction test. The application will guide you through the process and display your reaction time at the end of each test.

## Contributing

If you'd like to contribute to the Reaction Test Application, please follow these guidelines:

1. Fork the repository
2. Create a new branch for your feature or bug fix
3. Make your changes and commit them with descriptive messages
4. Push your branch to your fork
5. Open a pull request to the main repository
