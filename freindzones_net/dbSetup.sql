CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS follows(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  follower VARCHAR(255),
  following VARCHAR(255),
  FOREIGN KEY (follower) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (following) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';