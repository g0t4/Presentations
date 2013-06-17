unused code
    comment about open-exchange-rates
    exports.patterns

getEachListing
    comingles what with how
    might be better for consumers to compose this anyways, then they can control degree of parallelism and delays etc

setup code styles and format code consistently
    point out differences
    not perfect - preceding comma style collapse to one line

add test of getListings

extract html scraper
    add test - html with one listing - should have one listing
      require('fs').writeFileSync('listings.html', text);
    add broken test - html with one listing - should have price
      fix missing price

could go on about virtues of testing