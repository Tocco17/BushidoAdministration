/** @type {import('next').NextConfig} */
const nextConfig = {
    experimental : {
        outputStandalone : true
    },
    reactStrictMode: true,
    images: {
        domains: ['bushidokarate.net'],
      },
}

module.exports = nextConfig
