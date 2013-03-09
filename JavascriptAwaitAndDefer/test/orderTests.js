require('tamejs').register();
require('coffee-script');
require('iced-coffee-script');
require('streamline').register({
    fibers: false,
    cache: true,
    verbose: true
});

function addTest(file) {
    module.exports[file] = require(file);
}

/*
 addTest('./1_orderPyramidOfDoom.js');
 addTest('./1_orderPyramidOfDoom.coffee');
 addTest('./2_orderTameJS.tjs');
 addTest('./2_orderIcedCoffeeScript.iced');
 addTest('./orderStep.coffee');
 addTest('./orderInvoke.coffee');
 addTest('./orderNue.coffee');
 addTest('./orderAsyncjs.coffee');
 addTest('./orderQ.coffee');
 addTest('./orderStreamline._coffee');
 */
addTest('./orderStreamline._js');


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