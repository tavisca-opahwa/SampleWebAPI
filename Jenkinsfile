pipeline{
    agent {label 'master'}
    stages{
        stage('build'){
            steps{ 
                sh 'dotnet restore API.sln --source https://api.nuget.org./v3/index.json'
                sh 'dotnet build API.sln -p:Configuration=release -v:n'
                sh 'dotnet test API.Tests/API.Tests.csproj'
            }
            
        }
    }
}