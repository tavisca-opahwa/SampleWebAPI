pipeline
 {

    agent any

 


    stages 
	{

            stage('Build')
			 {
		
            steps {
			
                sh 'dotnet build ApiTest.sln -p:configuration=release -v:n'
    
				            echo "Building......."
 
				    }
		
        }
    
			stage('Test') 
			{
			
            steps {

				                sh 'dotnet test'
   
				             	echo "Testing.........."
  
				          }
 
			}
 
			 stage('Publish')
 					{
				
            steps {
					
                sh 'dotnet publish'
					
                echo "Testing.........."

						  }

        				}
			
    }

 			   post
				{

        		always
				{

            archiveArtifacts '**'

    				    }
			
    	}
   
               		 
}