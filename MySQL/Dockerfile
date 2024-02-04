# Derivando da imagem oficial do MySQL
FROM mysql:5.7
# Adicionando os scripts SQL para serem executados na criação do banco
COPY ./db/ /docker-entrypoint-initdb.d/


# $ sudo docker build -t backoffice-db .
# referencia: https://johnfercher.medium.com/mysql-docker-7ff6d50d6cf1

# Rodando o container:
# $ docker run -d -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=Backoffice -e MYSQL_USER=MainUser -e MYSQL_PASSWORD=root backoffice-db

# Acesso manual ao banco
# $ docker exec -it container_id bash
#
# root@container_id:/# mysql -u root -p
# Enter password: RootPassword