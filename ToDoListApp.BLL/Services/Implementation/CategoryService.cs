using AutoMapper;
using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.CategoryDtos;
using ToDoListApp.DAL.Entities;
using ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Abstraction;
using ToDoListApp.BLL.Services.Abstraction;

namespace ToDoListApp.BLL.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult<List<GetCategoryDto>>> GetAllCategoriesDtosAsync()
        {
            try
            {
                var result = await _unitOfWork.Categories.GetAllEntitiesAsync(null, t => t.ToDoItems, t => t.User);
                var mappedResult = _mapper.Map<List<GetCategoryDto>>(result);

                return new ResponseResult<List<GetCategoryDto>>
                (
                    true,
                    null,
                    mappedResult
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<List<GetCategoryDto>>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }

        public async Task<ResponseResult<GetCategoryDto>> GetCategoryDtoByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.Categories.GetEntityByIdAsync(id, t => t.ToDoItems, t => t.User);
                var mappedResult = _mapper.Map<GetCategoryDto>(result);

                return new ResponseResult<GetCategoryDto>
                (
                    true,
                    null,
                    mappedResult
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<GetCategoryDto>
                (
                   false,
                   ex.Message,
                   null
                );
            }
        }

        public async Task<ResponseResult<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var mappedResult = _mapper.Map<Category>(createCategoryDto);
                await _unitOfWork.Categories.AddEntityAsync(mappedResult);
                var changes = await _unitOfWork.SaveChangesAsync();

                if (changes > 0)
                {
                    return new ResponseResult<CreateCategoryDto >
                    (
                        true,
                        null,
                        createCategoryDto
                    );
                }

                return new ResponseResult<CreateCategoryDto>
                (
                    false,
                    "Failed to create the Category.",
                    null
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<CreateCategoryDto>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }

        public async Task<ResponseResult<int>> DeleteCategoryAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.Categories.GetEntityByIdAsync(id);

                if (result != null)
                {
                    await _unitOfWork.Categories.DeleteEntityAsync(id);
                    var changes = await _unitOfWork.SaveChangesAsync();

                    if (changes > 0)
                    {
                        return new ResponseResult<int>
                        (
                            true,
                            null,
                            id
                        );
                    }
                }

                return new ResponseResult<int>
                (
                    false,
                    "Failed to delete the Category.",
                    id
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<int>
                (
                    false,
                    ex.Message,
                    id
                );
            }
        }

        public async Task<ResponseResult<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var result = await _unitOfWork.Categories.GetEntityByIdAsync(updateCategoryDto.Id);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<Category>(updateCategoryDto);
                    _unitOfWork.Categories.UpdateEntity(mappedResult);
                    var changes = await _unitOfWork.SaveChangesAsync();

                    if (changes > 0)
                    {
                        return new ResponseResult<UpdateCategoryDto>
                        (
                            true,
                            null,
                            updateCategoryDto
                        );
                    }
                }

                return new ResponseResult<UpdateCategoryDto>
                (
                    false,
                    "Failed to update the Category.",
                    null
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<UpdateCategoryDto>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }

        public async Task<ResponseResult<bool>> CheckUniqueNameAsync(string name)
        {
            try
            {
                var result = await _unitOfWork.Categories.AnyAsync(t => t.Name == name);

                if (!result)
                {
                    return new ResponseResult<bool>
                    (
                        true,
                        null,
                        true
                    );
                }

                return new ResponseResult<bool>
                (
                    false,
                    "Name is not unique.",
                    false
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool>
                (
                    false,
                    ex.Message,
                    false
                );
            }
        }
    }
}
