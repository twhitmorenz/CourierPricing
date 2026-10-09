# Courier Pricing example

## Design

- Parcels are priced via strategy (IParcelPricingStrategy);  
    - implementations of various sophistication are included.
- Orders are priced via strategy (IOrderPricingStrategy);
    - various implementations are included;
    - including using composition & delegation to implement more sophisticated behaviors.

## Running

Use 'dotnet test' to run.


© 2026 Tom Whitmore. All rights reserved.