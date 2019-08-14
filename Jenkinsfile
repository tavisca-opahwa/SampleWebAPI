pipeline{
    agent {label 'master'}
    stages{
        stage('build'){
            sh 'git clone https://github.com/tavisca-opahwa/SampleWebAPI.git'
            sh  'dotnet restore API.sln --source https://api.nuget.org/v3/index.json'
            sh 'dotnet build API.sln -p:Configuration=release -v:n'
            
        }
    }
}