# Assessment - Brewery and wholesale management

Below are listed the functional and technical requirements sent by client.

## Functional requirements

    FR1- List all the beers by brewery.
    FR2- A brewer can add new beer.
    FR3- A brewer can delete a beer.
    FR4- Add the sale of an existing beer to an existing wholesaler.
    FR5- A wholesaler can update the remaining quantity of a beer in his stock.
    FR6- A client can request a quote from a wholesaler.
    
* FR6 output => 2 scenarios:

1. If successful, the method returns a price and a summary of the quote.
  * A 10% discount is applied above 10 drinks
  * A 20% discount is applied above 20 drinks
2. If there is an error, it returns an exception and a message to explain the reason:
  * The order cannot be empty
  * The wholesaler must exist
  * There can't be any duplicate in the order
  * The number of beers ordered cannot be greater than the wholesaler's stock
  * The beer must be sold by the wholesaler
  
## Business constraints
  * A brewer brews one or several beers.
  * A beer is always linked to a brewer.
  * A beer can be sold by several wholesalers.
  * A wholesaler sells a defined list of beers, from any brewer, and has only a limited stock of those beers.

The beers sold by the wholesaler have a fixed price, imposed by the brewery.
 * For this assessment, it is considered that all sales are made without VAT.
 * The database can pre-filled.
