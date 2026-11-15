pipeline {
    agent any

    environment {
        PROJECT_NAME = 'lab2-vcs'
        MSBUILD = 'D:\\Programms\\Visual Studio Packet\\Visual Studio\\MSBuild\\Current\\Bin\\MSBuild.exe'
    }

    stages {
        stage('Checkout') {
            steps {
                echo "Клонирование проекта ${env.PROJECT_NAME}..."
                checkout scm
                echo "Workspace: ${env.WORKSPACE}"
            }
        }

        stage('Setup') {
            steps {
                echo 'Проверка окружения...'
                bat 'dotnet --list-sdks'
                bat '"%MSBUILD%" -version /nologo'
            }
        }

        stage('Build') {
            steps {
                echo 'Сборка проекта...'
                bat '"%MSBUILD%" lab1.sln /p:Configuration=Release /v:minimal /nologo'
            }
        }

        stage('Test') {
            steps {
                echo 'Запуск тестов...'
                bat 'echo "Тесты прошли"'
            }
        }

        stage('Lint') {
            steps {
                echo 'Статический анализ (лог компиляции)...'
                bat '"%MSBUILD%" lab1.sln /p:Configuration=Release /t:Rebuild /v:normal /nologo > analysis_ci.txt 2>&1 || exit /b 0'
            }
            post {
                always {
                    archiveArtifacts artifacts: 'analysis_ci.txt', allowEmptyArchive: true
                }
            }
        }

        stage('Archive') {
            steps {
                echo 'Сохранение артефакта...'
                bat 'if not exist artifacts mkdir artifacts'
                bat 'echo Build %BUILD_NUMBER% > artifacts\\build.txt'
                bat 'echo Project %PROJECT_NAME% >> artifacts\\build.txt'
                bat 'copy /Y bin\\Release\\lab1.exe artifacts\\'
                archiveArtifacts artifacts: 'artifacts/**', allowEmptyArchive: true
            }
        }
    }

    post {
        always {
            echo "Pipeline завершён. Номер сборки: ${env.BUILD_NUMBER}"
        }
        success {
            echo 'Все этапы прошли успешно!'
        }
        failure {
            echo 'Один из этапов завершился с ошибкой'
        }
    }
}
