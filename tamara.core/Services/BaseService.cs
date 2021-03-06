﻿using tamara.core.infrastructure;

namespace tamara.webhook.core.services
{
    public abstract class BaseService
    {
        protected IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork = null)
        {
            if (unitOfWork == null)
            {
                this.unitOfWork = new UnitOfWork();
            }
            else
            {
                this.unitOfWork = unitOfWork;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            this.unitOfWork.Dispose();
        }
    }
}
