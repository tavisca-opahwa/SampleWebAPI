    pipeline{
    agent { label 'master' }
    parameters{
        string(
            name: "GIT_HTTPS_PATH",
            defaultValue: "https://github.com/tavisca-opahwa/SampleWebApi.git",
            description: "GIT HTTPS PATH"
        )
        string(
            name: "Project_Name",
            defaultValue: "api"
        )
        string(
            name: "SOLUTION_PATH",
            defaultValue: "API.sln",
            description: "SOLUTION_PATH"
        )
        string(
            name: "DOTNETCORE_VERSION",
            defaultValue: "2.1",
            description: "Version"
        )
        string(
            name: "TEST_SOLUTION_PATH",
            defaultValue: "API.Tests/API.Tests.csproj",
            description: "TEST SOLUTION PATH"
        )
        
        string(
            name: "PROJECT_PATH",
            defaultValue: "API/API.csproj",
        )
         string(
            name: "DOCKERFILE",
            defaultValue: "mcr.microsoft.com/dotnet/core/aspnet",
        )
         string(
            name: "ENV_NAME",
            defaultValue: "Api",
        )
         string(
            name: "SOLUTION_DLL_FILE",
            defaultValue: "API.dll",
        )
        string(
            name: "DOCKER_USER_NAME",
            description: "Enter Docker hub Username"
        )
        string(
            name: "DOCKER_PASSWORD",
            description:  "Enter Docker hub Password"
        )
        choice(
            name: "RELEASE_ENVIRONMENT",
            choices: ["Build","Deploy"],
            description: "Tick what you want to do"
        )
    }
    stages{
        stage('Build'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Build" || params.RELEASE_ENVIRONMENT == "Deploy"}
            }
            steps{
                powershell '''
                    echo '====================Restore Start ================'
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json
                    echo '=====================Restore Completed============'
                    echo '====================Build Start ================'
                    dotnet build ${PPOJECT_PATH} 
                    echo '=====================Build Completed============'
                     echo '====================Test Start ================'
                    dotnet test ${TEST_SOLUTION_PATH}
                    echo '=====================Test Completed============'
                     echo '====================Publish Start ================'
                    dotnet publish ${PROJECT_PATH}
                    
                    echo '=====================Publish Completed============'
                '''
            }
        }
        stage ('Creating Docker Image') {
            when{
                expression{params.RELEASE_ENVIRONMENT == "Deploy"}
            }
            steps {
                writeFile file: 'API/bin/Debug/netcoreapp2.1/publish/Dockerfile', text: '''
                        FROM mcr.microsoft.com/dotnet/core/aspnet\n
                        ENV NAME ${Project_Name}\n
                        CMD ["dotnet", "${SOLUTION_DLL_FILE}"]\n'''
                
                powershell "docker build API/bin/Debug/netcoreapp2.1/publish/ --tag=${Project_Name}:${BUILD_NUMBER}"    
                powershell "docker tag ${Project_Name}:${BUILD_NUMBER} ${DOCKER_USER_NAME}/${Project_Name}:${BUILD_NUMBER}"
                powershell "docker login -u ${DOCKER_USER_NAME} -p ${DOCKER_PASSWORD}" 
                powershell "docker push ${DOCKER_USER_NAME}/${Project_Name}:${BUILD_NUMBER}"
            }
        }
    }
    post{
        always{
            deleteDir()
       }
    }
}
