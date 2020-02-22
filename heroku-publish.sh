[!bash]
sudo heroku container:push web -a=escalada-webserver
sudo heroku container:release web -a=escalada-webserver
heroku open -a=escalada-webserver
