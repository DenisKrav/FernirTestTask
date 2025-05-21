FROM jenkins/jenkins:lts

USER root
RUN apt-get update && apt-get install -y sudo python3-pip && \
    pip3 install jenkins-job-builder

USER jenkins
