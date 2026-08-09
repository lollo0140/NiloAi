import adapter from '@sveltejs/adapter-static';

const config = {
    kit: {
        adapter: adapter({
            pages: '../wwwroot',
            assets: '../wwwroot',
            precompress: false,
            strict: true
        })
    }
};

export default config;