USE Backoffice;
CREATE TABLE user (
    id INT PRIMARY KEY AUTO_INCREMENT,
    is_active BOOLEAN NOT NULL,
    created_date DATETIME,
    name VARCHAR(200)
);
SET character_set_client = utf8;
SET character_set_connection = utf8;
SET character_set_results = utf8;
SET collation_connection = utf8_general_ci;
INSERT INTO user (is_active, created_date, name) VALUES (1, '2018-07-21', 'João Fulano');