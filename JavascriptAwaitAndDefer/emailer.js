module.exports.sendEmail = function (message, callback) {
    console.log('email sent', message);
    callback(null);
};