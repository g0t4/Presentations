require('tamejs').register();
require('coffee-script');
require('iced-coffee-script');

module.exports.orderNestedAsync = require('./orderNestedAsync.js');
module.exports.orderTameJS = require('./orderTameJS.tjs');
module.exports.orderNestedAsyncCoffee = require('./orderNestedAsync.coffee');
module.exports.orderIcedCoffeeScript = require('./orderIcedCoffeeScript.iced');
module.exports.orderStep = require('./orderStep.coffee');
module.exports.orderInvoke = require('./orderInvoke.coffee');
module.exports.orderNue = require('./orderNue.coffee');

// Things to consider when choosing an alternative:
// error handling (can this cascade to the end like unhandled exceptions)
// can you pass data from prior steps forward easily
// readability / flow control, does it look like synchronous code in terms of simplicity?
// how different is it from standard javascript/coffescript?  If it's odd it will be hard to port that code as needed and defeats the purpose of making it easily separable (likely you will employ several techniques for organizing your code)

// CPS transforms - problem is right now we don't have a way to create one error handler, verbose
// step - error handling is ceremonial

// https://github.com/nakamura-to/nue - like step but with error handling and sharing data between steps easily
// https://gist.github.com/c16690e2102c0ea442a7
// sample of synchronize and fibers (brings promise of await and defer with error handling magic)