var tslintHtmlReport = require('tslint-html-report');
tslintHtmlReport({
    tslint: 'tslint.json',
    srcFiles: 'src/**/*.ts',
    outDir: 'reports/lint',
    html: 'index.html',
    exclude: [],
    breakOnError: false,
    typeCheck: true,
    tsconfig: 'tsconfig.json' // path to tsconfig.json
});
