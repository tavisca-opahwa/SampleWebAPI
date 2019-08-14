pipeline{
    agent {label 'master'}
    stages{
        stage('build'){
            steps{ 
                sh 'dotnet restore API.sln --source https://api.nuget.org./v3/index.json'
            }
            
        }
    }
}