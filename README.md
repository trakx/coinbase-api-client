![.NET Core](https://github.com/trakx/coinbase-api-client/workflows/.NET%20Core/badge.svg) [![Codacy Badge](https://app.codacy.com/project/badge/Grade/31a15ad737034ec69c8f7fdbee66290e)](https://www.codacy.com/gh/trakx/coinbase-api-client/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=trakx/coinbase-api-client&amp;utm_campaign=Badge_Grade) [![Codacy Badge](https://app.codacy.com/project/badge/Coverage/31a15ad737034ec69c8f7fdbee66290e)](https://www.codacy.com/gh/trakx/coinbase-api-client/dashboard?utm_source=github.com&utm_medium=referral&utm_content=trakx/coinbase-api-client&utm_campaign=Badge_Coverage)

# coinbase-api-client
C# implementation of a Coinbase api client

## Creating your local .env file
In order to be able to run some integration tests, you should create a `.env` file in the `src` folder with the following variables:
```secretsEnvVariables
CoinbaseCustodyApiConfiguration__AccessKey=********
CoinbaseCustodyApiConfiguration__PassPhrase=********
```
