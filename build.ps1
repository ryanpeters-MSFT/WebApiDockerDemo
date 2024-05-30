docker build -f .\Dockerfile . -t binarydad/webapidockerdemo:latest
docker image push binarydad/webapidockerdemo:latest

docker run --name WebApiDockerDemo -d -p 9274:8080 -e "WELCOME_MSG=hello world!" binarydad/webapidockerdemo:latest

