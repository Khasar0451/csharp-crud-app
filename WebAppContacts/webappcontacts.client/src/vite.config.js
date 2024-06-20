import { defineConfig } from 'vite';

export default defineConfig({
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5255',
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
