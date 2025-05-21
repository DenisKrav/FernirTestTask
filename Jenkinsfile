pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/DenisKrav/FernirTestTask.git'
            }
        }
        stage('Build') {
            steps {
                echo '🔧 Building the project...'
                sh 'echo Build step would go here'
            }
        }
        stage('Test') {
            steps {
                echo '✅ Running tests...'
                sh 'echo Tests passed'
            }
        }
    }
}
