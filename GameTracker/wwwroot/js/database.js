const mysql = require('mysql2');
const dbConnection = mysql.createPool({
    host: 'localhost', // MYSQL HOST NAME
    user: 'root',        // MYSQL USERNAME
    password: 'Sharingan98',    // MYSQL PASSWORD
    database: 'gametrackerdb'      // MYSQL DB NAME
}).promise();
module.exports = dbConnection;