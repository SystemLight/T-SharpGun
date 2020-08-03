const ph = require("path");

module.exports = {
    context: __dirname,
    resolve: {
        extensions: [".js", ".ts", ".jsx", ".tsx"],
        alias: {"@": ph.join(__dirname, "src")}
    },
    entry: "src/index.js",
    output: {
        filename: "js/[name].bundle.js",
        path: "./dist",
        publicPath: "/"
    },
    module: {
        rules: []
    },
    plugins: []
};
