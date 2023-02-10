versiyon uyumsuzluğu fix-----

npm uninstall -g @angular/cli

npm cache clean

npm install -g @angular/cli@12.2.11

https://nodejs.org/download/release/v14.15.0/node-v14.15.0-x64.msi
kurun...

1) ilk olarak docker desktop, vs code ve visual studio 2022 kurulur
2) aşağıdaki docker compose ile ilgili container ler yüklenir

//////
version: '3.8'

services:

  db:
    container_name: pg_container
    image: postgres
    restart: always
    environment:
      POSTGRES_USER: root
      POSTGRES_PASSWORD: root
      POSTGRES_DB: test_db
    ports:
      - "5432:5432"
  pgadmin:
    container_name: pgadmin4_container
    image: dpage/pgadmin4
    restart: always
    environment:
      PGADMIN_DEFAULT_EMAIL: admin@admin.com
      PGADMIN_DEFAULT_PASSWORD: root
    ports:
      - "5050:80"
//

 # docker run -d -p 1453:15672 -p 5672:5672 --name rabbitmqcontainer rabbitmq:3-management
 
 # docker pull rabbitmq // guest - guest
 
3)  bu adresten angular ve vs code yüklenir >> https://www.c-sharpcorner.com/blogs/configuring-angularjs-in-vs-code 

4) appsettings.json dosyasından db için gerekli ip ayarı yapılır

5) packed manager consele ile update-database ile migration dosyaları postgresql db sine yüklenir

6) vs code ile frontend klasörüne girilir ve ng serve --open komutu ile proje çalıştırılır

7) ConsumerRabbitMQ ve Rise-Arifozbey katmanları vs studio da çalıştırılır
