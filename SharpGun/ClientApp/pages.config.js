const splitChunks = {
    // chunks : all, async, and initial
    chunks: "async",
    minSize: 30720,
    maxSize: 0,
    minChunks: 1,
    maxAsyncRequests: 6,
    maxInitialRequests: 4,
    automaticNameDelimiter: "-",
    automaticNameMaxLength: 30,
    cacheGroups: {
        common: {
            name: "common",
            chunks: "all",
            priority: -20,
            minChunks: 2,
            reuseExistingChunk: true
        },
        vendors: {
            test: /[\\/]node_modules[\\/]/,
            name: "vendors",
            chunks: "all",
            priority: -10
        },
        react: {
            test: /[\\/]node_modules[\\/](scheduler|react|react-dom)/,
            name: "react",
            chunks: "all",
            enforce: true
        },
        antd: {
            test: /[\\/]node_modules[\\/](@ant-design|antd)[\\/]/,
            name: "antd",
            chunks: "all"
        },
        styles: {
            name: "styles",
            test: /\.css$/,
            chunks: "all",
            enforce: true
        }
    }
};

module.exports = {
    splitChunks,
    isExtractCss: true,
    defaultOpt: {
        title: "React WEB"
    },
    chunksOnAllPages: ["common", "vendors", "react", "antd"],
    pages: {pageName: "index", type: "tsx"}
};
