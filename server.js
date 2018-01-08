var express = require('express');
var app = express();
var fs = require('fs');
var bodyparser = require('body-parser');
var router = express.Router();
var mongoOp = require("./models/mongo");

app.use(bodyparser.json());
app.use(bodyparser.urlencoded({ extended: false }));

router.get('/', function (req, res) {
    console.log('Test service execution started');
    res.json({ "error": false, "message": 'Welcome to Cornershops In Rest node services' });
});

router.route("/users")
    .get(function (req, res) {
        var response = {};
        mongoOp.find({}, function (err, data) {
            // Mongo command to fetch all data from collection.
            if (err) {
                response = { "error": true, "message": "Error fetching data" };
            } else {
                response = { "error": false, "message": data };
            }
            res.json(response);
        });
    })
    .post(function (req, res) {
        var db = new mongoOp();
        var response = {};
        db.userEmail = req.body.email;
        db.userName = req.body.name;
        db.save(function (err) {
            if (err) {
                response = { "error": true, "message": "Error adding data" };
            } else {
                response = { "error": false, "message": "User Added to the system" };
            }
            res.json(response);
        });
    });

router.route("/users/:id")
    .get(function (req, res) {
        var response = {};
        mongoOp.findById(req.params.id, function (err, data) {
            if (err) {
                response = { "error": true, "message": "Error fetching data" };
            } else {
                response = { "error": false, "message": data };
            }
            res.json(response);
        });
    })
    .put(function (req, res) {
        var response = {};
        mongoOp.findById(req.params.id, function (err, data) {
            if (err) {
                response = { "error": true, "message": "Error fetching data" };
            }
            else {
                if (req.body.email !== undefined) {
                    // case where email needs to be updated.
                    data.email = req.body.email;
                }
                if (req.body.name !== undefined) {
                    // case where password needs to be updated
                    data.userName = req.body.name;
                }

                data.save(function (err) {
                    if (err) {
                        response = { "error": true, "message": "Error updating data" };
                    }
                    else {
                        response = { "error": false, "message": "Data is updated for " + req.params.id };
                    }
                    res.json(response);
                }

                );
            }
        })
    })
app.use('/', router);

var server = app.listen('8081', function () {
    var host = server.address().address;
    var port = server.address().port;
    console.log("Example app listening at http://%s:%s", host, port)
});