using AutoMapper;
using System.Linq.Expressions;
using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.CategoryDtos;
using ToDoListApp.BLL.Services.Abstraction;
using ToDoListApp.DAL.Entities;
using ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Abstraction;

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

        public async Task<ResponseResult<List<GetCategoryDto>>> GetAllCategoriesDtosByUserIdAsync(string userId)
        {
            try
            {
                var result = await _unitOfWork.Categories.GetAllEntitiesAsync(c => c.UserId == userId, t => t.ToDoItems, t => t.User);
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

        public async Task<ResponseResult<CreateCategoryDto>> CreateCategoryDtoAsync(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var mappedResult = _mapper.Map<Category>(createCategoryDto);
                await _unitOfWork.Categories.AddEntityAsync(mappedResult);
                var changes = await _unitOfWork.SaveChangesAsync();

                if (changes > 0)
                {
                    return new ResponseResult<CreateCategoryDto>
                    (
                        true,
                        null,
                        createCategoryDto
                    );
                }
                else
                {
                    return new ResponseResult<CreateCategoryDto>
                    (
                    false,
                    "An error occurred while creating the category.",
                    null
                    );
                }
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

        public async Task<ResponseResult<int>> DeleteCategoryDtoAsync(int id)
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
                    else
                    {
                        return new ResponseResult<int>
                        (
                            false,
                            "An error occurred while deleting the category.",
                            id
                        );
                    }
                }
                else
                {
                    return new ResponseResult<int>
                    (
                    false,
                    "Category not found.",
                    id
                    );
                }

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

        public async Task<ResponseResult<UpdateCategoryDto>> UpdateCategoryDtoAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var result = await _unitOfWork.Categories.GetEntityByIdAsync(updateCategoryDto.Id);
                if (result != null)
                {
                    result.Name = updateCategoryDto.Name;
                    result.Description = updateCategoryDto.Description;
                    
                    _unitOfWork.Categories.UpdateEntity(result);
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
                    else
                    {
                        return new ResponseResult<UpdateCategoryDto>
                        (
                            false,
                            "An error occurred while updating the category.",
                            null
                        );
                    }
                }
                else
                {
                    return new ResponseResult<UpdateCategoryDto>
                    (
                        false,
                        "Category not found.",
                        null
                    );
                }

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

        public async Task<ResponseResult<bool>> CheckCategoryUniqueNameAsync(Expression<Func<Category, bool>> predicate)
        {
            try
            {
                var result = await _unitOfWork.Categories.AnyAsync(predicate);

                if (!result)
                {
                    return new ResponseResult<bool>
                    (
                        true,
                        null,
                        true
                    );
                }
                else
                {
                    return new ResponseResult<bool>
                    (
                        false,
                        "A category with this name already exists.",
                        false
                    );
                }
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

        public async Task<ResponseResult<string>> CreateDefaultCategoryAsync(string UserId)
        {
            try
            {
                var defaultCategory = new Category
                {
                    Name = "General",
                    UserId = UserId,
                    IsSystem = true
                };
                await _unitOfWork.Categories.AddEntityAsync(defaultCategory);
                var changes = await _unitOfWork.SaveChangesAsync();
                if (changes > 0)
                {
                    return new ResponseResult<string>
                    (
                        true,
                        null,
                        "Default category created successfully."
                    );
                }
                else
                {
                    return new ResponseResult<string>
                    (
                        false,
                        "Failed to create the default category.",
                        null
                    );
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<string>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }
    }
}
