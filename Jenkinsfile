pipeline{
    environment{
        RELEASE_ENVIORNMENT= ${params.RELEASE_ENVIORNMENT}
    }
    
    agent any
    parameters{
        string(
            name : 'GIT_SSH_PATH',
            defaultValue: 'https://github.com/tavisca-opahwa/SampleWebAPI.git',
            description: '',
        )
        string(
            name : 'SOLUTION_FILE_PATH',
            defaultValue: 'API.sln',
            description: '',
        )
        string(
            name : 'TEST_PROJECT_PATH',
            defaultValue: 'API.Tests/API.Tests.csproj',
            description: '',
        )
        string(
            name : 'NETCORE_VERSION',
            defaultValue: '',
            description: '',
        )
        choice(
            name : 'RELEASE_ENVIORNMENT',
            choices:"Build\nTest",
            description: '',
        )
    }
    stages{
        stage('Build'){
            when{
                expression{"${RELEASE_ENVIORNMENT}" == "Build"}
            }
            steps{ 
                sh '''
                dotnet${NETCORE_VERSION} restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org./v3/index.json,
                dotnet${NETCORE_VERSION} build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n,
                '''
            }
        }
        stage('Test'){
            when{
                expression{"${RELEASE_ENVIORNMENT}" == "Test"}
            }
            steps{ 
                sh '''
                dotnet${NETCORE_VERSION} test ${TEST_PROJECT_PATH} ,
                '''
            }
        }        
    }
    post{
        always{
            deleteDir()
        }
    }
}