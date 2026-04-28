import { motion } from 'framer-motion';

export function PageWrapper({ children, className = '' }) {
  return (
    <motion.div
      initial={{ opacity: 0, y: 15, scale: 0.97 }}
      animate={{ opacity: 1, y: 0, scale: 1 }}
      exit={{ opacity: 0, y: -10, scale: 0.97 }}
      transition={{ duration: 0.5, ease: 'easeOut' }}
      className={`w-full h-full ${className}`}
    >
      {children}
    </motion.div>
  );
}
