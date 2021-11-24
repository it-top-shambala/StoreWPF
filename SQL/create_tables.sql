-- Создание таблиц
CREATE TABLE tab_products
(
    id         INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name       VARCHAR(50) NOT NULL,
    annotation TEXT        NOT NULL,
    image      TEXT        NOT NULL
);

CREATE TABLE tab_product_prices
(
    id         INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    product_id INT  NOT NULL UNIQUE,
    price      REAL NOT NULL DEFAULT 0.0,
    FOREIGN KEY (product_id) REFERENCES tab_products (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_product_amounts
(
    id         INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    product_id INT NOT NULL UNIQUE,
    amount     INT NOT NULL DEFAULT 0,
    FOREIGN KEY (product_id) REFERENCES tab_products (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_accounts
(
    id        INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    login     VARCHAR(50) NOT NULL UNIQUE,
    password  VARCHAR(50) NOT NULL,
    is_active BOOL        NOT NULL DEFAULT TRUE
);

CREATE TABLE tab_users
(
    id         INT          NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50)  NOT NULL,
    last_name  VARCHAR(75)  NOT NULL,
    email      VARCHAR(255) NOT NULL,
    phone      VARCHAR(50)  NOT NULL,
    FOREIGN KEY (id) REFERENCES tab_accounts (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_role_types
(
    id   INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE tab_roles
(
    id           INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    account_id   INT NOT NULL,
    role_type_id INT NOT NULL,
    FOREIGN KEY (account_id) REFERENCES tab_accounts (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (role_type_id) REFERENCES tab_role_types (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_baskets
(
    id      INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL UNIQUE,
    FOREIGN KEY (user_id) REFERENCES tab_users (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_orders
(
    id         INT      NOT NULL AUTO_INCREMENT PRIMARY KEY,
    date_time  DATETIME NOT NULL,
    product_id INT      NOT NULL UNIQUE,
    amount     INT      NOT NULL DEFAULT 0,
    basket_id  INT      NOT NULL,
    FOREIGN KEY (product_id) REFERENCES tab_products (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (basket_id) REFERENCES tab_baskets (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

CREATE TABLE tab_sales
(
    id        INT      NOT NULL AUTO_INCREMENT PRIMARY KEY,
    date_time DATETIME NOT NULL,
    basket_id INT      NOT NULL,
    FOREIGN KEY (basket_id) REFERENCES tab_baskets (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

--# Создание представлений
CREATE VIEW view_products AS
SELECT tab_products.id AS 'id',
       tab_products.name AS 'name',
       tab_product_prices.price AS 'price',
       tab_product_amounts.amount AS 'amount',
       tab_products.annotation AS 'annotation',
       tab_products.image AS 'image'
FROM tab_products
         JOIN tab_product_amounts
              ON tab_products.id = tab_product_amounts.product_id
         JOIN tab_product_prices
              ON tab_products.id = tab_product_prices.product_id
ORDER BY tab_products.name;

--  Информация о всех пользователях
SELECT
    tab_users.id AS 'id',
    tab_users.last_name AS 'last_name',
    tab_users.first_name AS 'first_name',
    tab_users.email AS 'email',
    tab_users.phone AS 'phone',
    tab_accounts.login AS 'login',
    tab_accounts.is_active AS 'is_active',
    tab_role_types.name AS 'role'
FROM tab_users
    JOIN tab_accounts
        ON tab_users.id = tab_accounts.id
    JOIN tab_roles
        ON tab_accounts.id = tab_roles.account_id
    JOIN tab_role_types
        ON tab_roles.role_type_id = tab_role_types.id
ORDER BY tab_users.last_name;
