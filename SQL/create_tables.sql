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
