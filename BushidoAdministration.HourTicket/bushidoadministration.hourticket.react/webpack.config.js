module.exports = {
    // altre configurazioni del webpack
    module: {
      rules: [
        {
          test: /\.(png|jpg|gif)$/i,
          use: [
            {
              loader: 'file-loader',
              options: {
                name: '[name].[ext]',
                outputPath: 'images/',
                publicPath: '/',
              },
            },
          ],
        },
      ],
    },
  };
  